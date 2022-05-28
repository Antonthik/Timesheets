using System;
using System.Collections.Generic;
using System.Text;
using Timesheets;

namespace TestProject
{
  public interface IPersonRepositoryTest
    {
        IReadOnlyList<Person> GetAll();
    }
}
