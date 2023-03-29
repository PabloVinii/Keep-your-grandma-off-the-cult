public interface INPCState 
{
    void Enter(NPCStateMachine stateMachine);
    void Update(NPCStateMachine stateMachine);
    void Exit(NPCStateMachine stateMachine);
}
