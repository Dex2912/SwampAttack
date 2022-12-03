using UnityEngine;

[RequireComponent(typeof(Enemy))] // привязывает скрипт
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState; // начальное состояние

    private Player _target; // приватный таргет к которому приравниваем таргет со скрипта Enemy
    private State _currentState; // текущее состояние

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target; // берем компонент со скрипта Enemy
        Reset(_firstState); // запускаем первое состояние (бег)
    }

    private void Update()
    {
        if (_currentState == null) // проверка на состояние на присудсивие следующего статуса
            return;

        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;
        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
