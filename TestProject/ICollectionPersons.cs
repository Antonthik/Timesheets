using System;
using System.Collections.Generic;
using System.Text;
using Timesheets;

namespace TestProject
{
    interface ICollectionPersons
    {
        IReadOnlyList<Person> GetAll();
    }
}
