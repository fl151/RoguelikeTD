public interface IState
{
    public abstract void Start();
    public abstract void OnTick();
    public abstract void Stop();
}
