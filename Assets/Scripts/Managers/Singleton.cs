using UnityEngine;

// ���׸� �̱���

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; //  �̱��� �ν��Ͻ��� �����ϴ� ����

    public static T Instance
    {
        get
        {
            if (instance == null) //  instance�� ��� �ִٸ�
            {
                instance = FindObjectOfType<T>(); // ���� ������ T Ÿ�� ������Ʈ�� ã��

                if (instance == null) // ���� ������ ���� ����
                {
                    GameObject singletonObj = new GameObject(typeof(T).Name);
                    instance = singletonObj.AddComponent<T>();
                    DontDestroyOnLoad(singletonObj);
                }
            }
            return instance; //  instance ��ȯ
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T; //  instance�� ������ ���� ������Ʈ�� �̱������� ����
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); //  �̹� �����ϸ� �ߺ� ������ ���� ����
        }
    }
}