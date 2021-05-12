namespace JevLogin
{
    internal interface IUpgradable
    {
        float Speed { get; set; }
        void Restore();
    }
}