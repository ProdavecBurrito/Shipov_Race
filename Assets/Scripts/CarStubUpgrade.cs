public class CarStubUpgrade : ICarUpgrade
{
    public static readonly ICarUpgrade Default = new CarStubUpgrade();

    public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
    {
        return upgradableCar;
    }
}

