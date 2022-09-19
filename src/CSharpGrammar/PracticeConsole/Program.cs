using PracticeConsole.Data;  //  Give reference to the location of classes
                             //   within the specified namespace
                             //  This allows the developer to avoid having to use a 
                             //   fully qualified name everytime a reference
                             //   is made to a class in the namespace

static void DisplayString(string text)
{
    Console.WriteLine(text);
}

Employment Job = CreateJob();
ResidentAddress Addres = CreateAddress();

Employment CreateJob()
{
    Employment job = null;
    try
    {
        job = new Employment();
        DisplayString($"Good Job {job.ToString()}");
        //  checking exceptions
        job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($"Greed good Job {job.ToString()}");

        //  Bad Data
        // job = new Employment("", SupervisoryLevel.Supervisor, 5.5);  //  empty title
        // job = new Employment("Boss", 10, 5.5);  Invalid supervisor level
        // job = new Employment("Boss", SupervisoryLevel.Supervisor, -5.5);  //  Negative Year
    }
    catch (ArgumentException ex)  // specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)  // Genral catch all
    {
        DisplayString("Runtime error: " + ex.Message);
    }
    return job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress address = new ResidentAddress();
    DisplayString($"Default Address {address.ToString()}");
    address = new ResidentAddress(10767, "106 St NW", null, null,
                                    "Edmonton", "AB");
    DisplayString($"Greedy Address {address.ToString()}");
        return address;
 }

