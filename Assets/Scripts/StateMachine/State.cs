namespace StateMachine
{
    public abstract class State<T>
    {
        protected T _context;

        protected State(T context)
        {
            _context = context;
        }

        public abstract void OnEnter();
    }
}