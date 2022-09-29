namespace LibraryTests;
using Library;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
  public void GetEdadTest() {
        DateTime naci = new DateTime(2003,06,09);
        Persona p1 = new Persona("54628979", "Roberto",naci);
        int expected=19;
        int result=p1.GetEdad();
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void GetCedulaTest(){
        DateTime naci = new DateTime(2003,06,09);
        Persona p1 = new Persona("54628979", "Roberto",naci);
        string expected="54628979";
        string result= p1.GetCedula();
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void IsValidaTest(){

        bool expected=true;
        bool result= Persona.IsCedulaValida("5.462.897-9");
        Assert.That(expected, Is.EqualTo(result));
        bool expected2=false;
        bool result2=Persona.IsCedulaValida("4356467442577");
        Assert.That(expected2, Is.EqualTo(result2));


    }


    
}