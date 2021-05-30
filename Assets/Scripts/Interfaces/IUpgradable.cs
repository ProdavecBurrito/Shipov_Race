public interface IUpgradable
{
    void Restore();
    float Speed { get; set; }
    int Ammo { get; set; }
}