// Defines the Employee class.
public class Employee
{
    // Stores the unique ID number of the employee.
    public int Id { get; set; }

    // Stores the employee's first name.
    public string FirstName { get; set; }

    // Stores the employee's last name.
    public string LastName { get; set; }

    // Overloads the == operator so two Employee objects
    // can be compared using their Id properties.
    public static bool operator ==(Employee employee1, Employee employee2)
    {
        // Check if both objects reference the same object.
        if (ReferenceEquals(employee1, employee2))
        {
            // Return true because they are the exact same object.
            return true;
        }

        // Check if either object is null.
        if (employee1 is null || employee2 is null)
        {
            // Return false because only one of the objects is null.
            return false;
        }

        // Compare the Id properties of the two Employee objects.
        return employee1.Id == employee2.Id;
    }

    // Overloads the != operator because comparison operators
    // must be overloaded in pairs.
    public static bool operator !=(Employee employee1, Employee employee2)
    {
        // Return the opposite result of the == operator.
        return !(employee1 == employee2);
    }

    // Overrides Equals so it is consistent with the overloaded == operator.
    public override bool Equals(object obj)
    {
        // Check whether the supplied object is an Employee.
        if (obj is Employee employee)
        {
            // Compare the Employee objects using their Id properties.
            return Id == employee.Id;
        }

        // Return false if the supplied object is not an Employee.
        return false;
    }

    // Overrides GetHashCode because Equals was overridden.
    public override int GetHashCode()
    {
        // Return the hash code based on the Employee Id.
        return Id.GetHashCode();
    }
}
