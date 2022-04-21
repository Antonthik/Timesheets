using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Timesheets.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonRepository _repository;



        private static readonly List<Person> data = new List<Person>() {
            new Person { Id = 1, FirstName = "Veda", LastName = "Richmond", Email =
            "ligula@necluctus.edu", Company = "Quisque Ac Libero LLP", Age = 42 },
            new Person { Id = 2, FirstName = "Demetria", LastName = "Andrews", Email =
            "feugiat.metus@penatibuset.org", Company = "Nulla Facilisi Foundation", Age = 31 },
            new Person { Id = 3, FirstName = "Byron", LastName = "Holmes", Email =
            "neque.Sed.eget@non.co.uk", Company = "Et Associates", Age = 63 },
            new Person { Id = 4, FirstName = "Alexander", LastName = "Cummings", Email =
            "egestas.ligula@ultricesDuisvolutpat.ca", Company = "Vel Institute", Age = 23 },
            new Person { Id = 5, FirstName = "Melinda", LastName = "Miles", Email =
            "justo.nec.ante@nonummyFusce.ca", Company = "Eu Nibh Vulputate Company", Age = 64 },
            new Person { Id = 6, FirstName = "Dustin", LastName = "Beck", Email =
            "iaculis@afeugiat.edu", Company = "Nec Diam Incorporated", Age = 35 },
            new Person { Id = 7, FirstName = "Ralph", LastName = "Maddox", Email =
            "ipsum@vulputatelacus.co.uk", Company = "Enim Corp.", Age = 22 },
            new Person { Id = 8, FirstName = "Levi", LastName = "Zamora", Email =
            "lectus.a.sollicitudin@nuncQuisque.com", Company = "Sodales At Velit Corp.", Age = 57},
            new Person { Id = 9, FirstName = "Driscoll", LastName = "Estrada", Email =
            "Phasellus@Craspellentesque.org", Company = "Id Mollis Nec LLC", Age = 37 },
            new Person { Id = 10, FirstName = "Hiram", LastName = "Mejia", Email =
            "lacus.Mauris@semper.ca", Company = "Donec Tincidunt Donec Industries", Age = 59 },
            new Person { Id = 11, FirstName = "Mason", LastName = "Jefferson", Email =
            "Integer.vitae.nibh@nibh.co.uk", Company = "Lectus Justo Ltd", Age = 65 },
            new Person { Id = 12, FirstName = "Nigel", LastName = "Rich", Email =
            "id@faucibusleoin.net", Company = "Tristique Ac Ltd", Age = 52 },
            new Person { Id = 13, FirstName = "Tarik", LastName = "Hughes", Email =
            "enim@ultricesDuisvolutpat.edu", Company = "Lacus Varius Et Associates", Age = 58 },
            new Person { Id = 14, FirstName = "Wallace", LastName = "Gross", Email =
            "Curabitur.ut.odio@anteMaecenasmi.co.uk", Company = "Rhoncus Id Corporation", Age =29 },
            new Person { Id = 15, FirstName = "Arden", LastName = "Rivers", Email =
            "magna.nec.quam@lobortis.net", Company = "Vivamus Corporation", Age = 59 },
            new Person { Id = 16, FirstName = "Vincent", LastName = "Fox", Email =
            "faucibus.Morbi.vehicula@ipsumdolor.edu", Company = "Imperdiet Dictum MagnaFoundation", Age = 54 },
            new Person { Id = 17, FirstName = "Aphrodite", LastName = "Randolph", Email =
            "ac@scelerisquesedsapien.org", Company = "Mattis Foundation", Age = 27 },
            new Person { Id = 18, FirstName = "Alisa", LastName = "Riggs", Email =
            "montes@scelerisque.edu", Company = "Rutrum Non Hendrerit Consulting", Age = 25 },
            new Person { Id = 19, FirstName = "Jaime", LastName = "Lott", Email =
            "velit.Quisque.varius@aliquetmolestie.net", Company = "Ut LLC", Age = 61 },
            new Person { Id = 20, FirstName = "Jamalia", LastName = "Buchanan", Email =
            "arcu.eu.odio@congue.ca", Company = "Curabitur Sed Tortor Ltd", Age = 61 },
            new Person { Id = 21, FirstName = "Raya", LastName = "Mckenzie", Email =
            "Integer.sem.elit@bibendumsedest.net", Company = "In Inc.", Age = 43 },
            new Person { Id = 22, FirstName = "Dante", LastName = "Blackwell", Email =
            "Cras.eget.nisi@Vestibulum.edu", Company = "Nec Foundation", Age = 48 },
            new Person { Id = 23, FirstName = "Kato", LastName = "Dickson", Email =
            "facilisis@doloregestas.co.uk", Company = "Augue Scelerisque Institute", Age = 60 },
            new Person { Id = 24, FirstName = "Clio", LastName = "Shaffer", Email =
            "tincidunt@eget.edu", Company = "Dui Augue Eu Limited", Age = 29 },
            new Person { Id = 25, FirstName = "Hamilton", LastName = "Kidd", Email =
            "magna@felisegetvarius.net", Company = "Enim Incorporated", Age = 26 },
            new Person { Id = 26, FirstName = "Kerry", LastName = "Oneil", Email =
            "Suspendisse.eleifend@Crasdolor.com", Company = "Interdum Inc.", Age = 48 },
            new Person { Id = 27, FirstName = "Mohammad", LastName = "Thompson", Email =
            "elit.pretium.et@malesuadafamesac.com", Company = "Facilisis Eget Ipsum Inc.", Age =34 },
            new Person { Id = 28, FirstName = "Vernon", LastName = "Cardenas", Email =
            "felis@conguea.org", Company = "Iaculis Quis Consulting", Age = 35 },
            new Person { Id = 29, FirstName = "Murphy", LastName = "Weaver", Email =
            "Proin@feugiatnecdiam.org", Company = "Integer Urna Institute", Age = 63 },
            new Person { Id = 30, FirstName = "Xena", LastName = "Hart", Email =
            "facilisis.facilisis.magna@loremutaliquam.net", Company = "Orci Industries", Age = 39},
            new Person { Id = 31, FirstName = "Ivor", LastName = "Lara", Email =
            "Proin.ultrices.Duis@lacuspede.com", Company = "Ante Foundation", Age = 30 },
            new Person { Id = 32, FirstName = "Dana", LastName = "Merritt", Email =
            "et.magnis@Sed.edu", Company = "Eget Industries", Age = 53 },
            new Person { Id = 33, FirstName = "Brielle", LastName = "Woodward", Email =
            "elit.Nulla@magna.edu", Company = "Lorem Vehicula Et Foundation", Age = 45 },
            new Person { Id = 34, FirstName = "Hasad", LastName = "Duran", Email =
            "et@nislsem.co.uk", Company = "Magna Suspendisse Consulting", Age = 49 },
            new Person { Id = 35, FirstName = "Quamar", LastName = "Moses", Email =
            "Proin.sed.turpis@imperdiet.co.uk", Company = "Eros Institute", Age = 32 },
            new Person { Id = 36, FirstName = "Scarlet", LastName = "Barlow", Email =
            "nisl.sem.consequat@idnunc.co.uk", Company = "Aenean Massa Consulting", Age = 58 },
            new Person { Id = 37, FirstName = "Courtney", LastName = "Foley", Email =
            "urna@mauris.org", Company = "Mauris Associates", Age = 47 },
            new Person { Id = 38, FirstName = "Kennedy", LastName = "Shields", Email =
            "Cras@Nullam.org", Company = "Id Nunc Interdum LLC", Age = 40 },
            new Person { Id = 39, FirstName = "Eve", LastName = "Maynard", Email =
            "metus.sit@lorem.ca", Company = "Pellentesque Ultricies Associates", Age = 30 },
            new Person { Id = 40, FirstName = "Debra", LastName = "Ellis", Email =
            "Nullam@pretium.ca", Company = "Nulla Tincidunt Industries", Age = 24 },
            new Person { Id = 41, FirstName = "Vivian", LastName = "Mcguire", Email =
            "ornare@at.net", Company = "Id Consulting", Age = 48 },
            new Person { Id = 42, FirstName = "Jason", LastName = "Mckinney", Email =
            "tempor.augue@purusNullam.com", Company = "Netus Et Inc.", Age = 48 },
            new Person { Id = 43, FirstName = "Patrick", LastName = "Small", Email =
            "fringilla@Proinsed.co.uk", Company = "Hendrerit Institute", Age = 61 },
            new Person { Id = 44, FirstName = "Drew", LastName = "Travis", Email =
            "scelerisque.scelerisque@velit.org", Company = "Penatibus Corp.", Age = 55 },
            new Person { Id = 45, FirstName = "Burke", LastName = "Miller", Email =
            "Suspendisse@aliquet.net", Company = "Quis Diam Pellentesque PC", Age = 41 },
            new Person { Id = 46, FirstName = "Ralph", LastName = "Medina", Email =
            "Class.aptent.taciti@mauris.edu", Company = "Lorem Ipsum Dolor Corp.", Age = 55 },
            new Person { Id = 47, FirstName = "Alana", LastName = "Madden", Email =
            "at.velit.Cras@aptenttacitisociosqu.net", Company = "Euismod Est Arcu Institute", Age= 33 },
            new Person { Id = 48, FirstName = "Salvador", LastName = "Cohen", Email =
            "magna.Duis@Phasellus.org", Company = "Purus PC", Age = 37 },
            new Person { Id = 49, FirstName = "Jenette", LastName = "Dejesus", Email =
            "adipiscing.Mauris.molestie@liberoduinec.ca", Company = "Lectus Justo Incorporated",Age = 56 },
            new Person { Id = 50, FirstName = "Ramona", LastName = "Gilliam", Email =
            "massa.Vestibulum@lectuspede.ca", Company = "Imperdiet Dictum LLP", Age = 24 },
            };

        public PersonController(PersonRepository repository)
        {
            _repository = repository;
        }

        //Поиск по id
        [HttpGet("persons/{id}")]
        public IActionResult GetId([FromRoute] int id)
        {
            try
            {
                List<Person> PersonsId = data.FindAll(p => p.Id == id);
                return Ok(PersonsId);
            }
            catch (Exception)
            {
                return Ok("ERR");
            }
        }
        //Поиск по имени
        [HttpGet("persons/searchTerm={term}")]
        public IActionResult GetName([FromRoute] string term)
        {
            try
            {
                List<Person> PersonsName = data.FindAll(p => p.FirstName == term);
                return Ok(PersonsName);
            }
            catch (Exception)
            {
                return Ok("ERR");
            }
        }
        //Создание
        [HttpPost("persons/create")]
        public IActionResult Create([FromBody] Person request)
        {
            try
            {
                var ind = data.FindIndex(p => p.Id == request.Id);
                if (ind >= 0)
                {                    
                    return Ok("Запись с этим Id существует, запись не добавлена!");
                }
                else
                {
                    data.Add(new Person
                    {
                        Id = request.Id,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        Company = request.Company,
                        Age = request.Age
                    });
                    return Ok("Запись добавлена.");
                }
            }
            catch (Exception)
            {
                return Ok("ERR");
            }
        }
        //Редактирование
        [HttpPut("persons/edit")]
        public IActionResult Edit([FromBody] Person request)
        {
            try
            {                
                var ind = data.FindIndex(p => p.Id == request.Id);
                if (ind >= 0)
                {
                    data[ind]=request;
                    return Ok(data[ind]);
                }
                else
                {
                    return Ok("Id не найден");
                }
               
            }
            catch (Exception)
            {
                return Ok("ERR");
            }
            
        }

        //Редактиирование
        [HttpDelete("persons/{Id}")]
        public IActionResult Del([FromRoute] int Id)
        {
            try
            {
                var ind = data.FindIndex(p => p.Id == Id);
                if (ind >= 0)
                {
                    data.RemoveAt(ind);
                    return Ok("Запись удалена.");
                }
                else
                {
                    return Ok("Id не найден");
                }

            }
            catch (Exception)
            {
                return Ok("ERR");
            }
        }
        //Создание
        [HttpPost("persons/createDB")]
        public IActionResult CreateDB([FromBody] Person request)
        {
            try
            {
                _repository.Create(new PersonDto
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Company = request.Company,
                    Age = request.Age
                });
                return Ok("Запись добавлена.");
            }
            catch (Exception)
            {
                
                return Ok("ERR");
            }
        }

        //Редактиирование
        [HttpDelete("persons/delete/{Id}")]
        public IActionResult DelDB([FromRoute] int Id)
        {
            try
            {
                _repository.Delete(Id);
                return Ok("Запись удалена.");
            }
            catch (Exception)
            {
                return Ok("ERR");
            }
        }
        //Поиск по имени
        [HttpGet("persons/searchTermDB={term}")]
        public IActionResult GetNameDB([FromRoute] string term)
        {
            try
            {
               var list= _repository.GetByName(term);
                return Ok(list);
            }
            catch (Exception)
            {
                return Ok("ERR");
            }
        }
        //Редактирование
        [HttpPut("persons/editDB")]
        public IActionResult EditDB([FromBody] Person request)
        {
            try
            {
                _repository.UpdateDB(new PersonDto
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Company = request.Company,
                    Age = request.Age
                });

                return Ok("Запись обновлена.");
            }
            catch (Exception)
            {
                return Ok("ERR");
            }

        }

    }
}


