using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;


namespace Timesheets
{
    public class PersonRepository : IPersonRepository
    {

        // Строка подключения
        private const string ConnectionString = @"Data Source=timesheets.db; Version=3;Pooling=True;Max Pool Size=100;";

        public PersonRepository()
        {
            //SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(PersonDto item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                connection.Execute("INSERT INTO persons(id, firstName,lastName,Email, company,age) VALUES(@id, @firstName,@lastName,@Email, @company,@age)",//добавляем в таблицу metricsagent
                   new
                   {
                       id = item.Id,
                       firstName = item.FirstName,
                       lastName = item.LastName,
                       Email = item.Email,
                       company = item.Company,
                       age = item.Age
                   });

            }
        }


        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM persons WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
        public IList<PersonDto> GetByName(string firstName)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<PersonDto>("SELECT * FROM persons WHERE firstName=@firstName",

                    new
                    {
                        firstName = firstName
                    }).ToList();
            }
        }
        public void UpdateDB(PersonDto item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE persons SET id = @id,firstName = @firstName,lastName=@lastName,Email = @Email,company = @company,age = @age WHERE id=@id",
                    new
                    {
                        id = item.Id,
                        firstName = item.FirstName,
                        lastName = item.LastName,
                        Email = item.Email,
                        company = item.Company,
                        age = item.Age
                    });
            }
        }
    }
}
