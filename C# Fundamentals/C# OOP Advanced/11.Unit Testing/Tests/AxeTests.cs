using System;
using Lab.Interfaces;
using NUnit.Framework;

public class AxeTests
{
    private const int AxeDurability = 10;
    private const int AxeAttack = 10;
    private const int DummyHealth = 20;
    private const int DummyXP = 20;
    private Axe axe;
    private ITarget dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyXP);
    }

    [Test]
    public void AxeLosesDurabilyAfterAttack()
    {
        //Act
        axe.Attack(dummy);

        //Assert
        Assert.AreEqual(AxeDurability - 1, axe.DurabilityPoints, "Axe Durability doesn't change after attack");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        //Act
        axe.Attack(dummy);
        axe.Attack(dummy);

        //Assert
        var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
    }
}