using Moq;
using System;
using System.Collections.Generic;
using Timesheets;
using Timesheets.Controllers;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
             Mock<IPersonRepositoryTest> mock = new Mock<IPersonRepositoryTest>();
             //PersonController controller = new PersonController(mock.Object);
            //�������������� ��������� ������� mosk-������
            mock.Setup(mock => mock.GetAll()).Returns(new 
                List<Person>(){
                new Person { Id = 48, FirstName = "Salvador", LastName = "Cohen", Email ="magna.Duis@Phasellus.org", Company = "Purus PC", Age = 37 },
                new Person { Id = 49, FirstName = "Jenette", LastName = "Dejesus", Email ="adipiscing.Mauris.molestie@liberoduinec.ca", Company = "Lectus Justo Incorporated",Age = 56 },
                new Person { Id = 50, FirstName = "Ramona", LastName = "Gilliam", Email = "massa.Vestibulum@lectuspede.ca", Company = "Imperdiet Dictum LLP", Age = 24 },
                new Person { Id = 51, FirstName = "Hiram", LastName = "Mejia",Email ="lacus.Mauris@semper.ca",Company="Donec Tincidunt Donec Industries",Age = 59}
            });

            //��������� ����������� ����� ������� mock
            ICollectionPersons reposit =new CollectionPersons(mock.Object);

            //������� ������� ������������ ������
            IReadOnlyList<Person> data_one = reposit.GetAll();
            IReadOnlyList<Person> data_two = reposit.GetAll();

            //��������
            Assert.NotEmpty(data_one);
            Assert.Equal(4, data_one.Count);
            Assert.Equal(data_one, data_two);




        }
    }
}
