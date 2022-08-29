using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float _movingSpeed;

    private Material _currentMaterial;
    private Connection _connection;

    public Connection Connection => _connection;
    //���� �� ��������� ����� ��������� ������� 
    // �� ������� ��� �������� �� ������ �����
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (!isLocalPlayer)
            transform.GetComponentInChildren<Camera>().gameObject.SetActive(false);
    }

    //�������� �� ������� (observer)
    private void OnEnable()
    {
        _connection = GetComponent<Connection>();
        _currentMaterial = GetComponent<MeshRenderer>().material;

        _connection.OnNeedChangePosition += pos => transform.position = pos;
        _connection.OnNeedChangeColor += color => _currentMaterial.color = color;
        _connection.OnNeedChangeScene += () => ClientNetworkManager.Instance.ServerChangeScene("Main");
    }

    //���� ��������� ����� 
    //�� ����� ������� ������ ���������
    //��� ������� ������ ������ �������� ������� �����
    void Update()
    {
        if (!isLocalPlayer) return;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * horizontal * _movingSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * vertical * _movingSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            _connection.CmdJerk();
    }

    //�������� ������ � ������ �� ������
    public void Enter(string login, string password) => _connection.CmdEnter(login, password);

    //������� �� ������� �������� ����
    [ClientRpc]
    private void RpcChangeColor(Color targetColor)
    {
        _currentMaterial.color = targetColor;
    }
}
