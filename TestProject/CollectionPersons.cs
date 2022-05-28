using System;
using System.Collections.Generic;
using System.Text;
using Timesheets;

namespace TestProject
{
    class CollectionPersons : ICollectionPersons
    {

        private readonly IPersonRepositoryTest _repository;
        private IReadOnlyList<Person> _index;
        public CollectionPersons(IPersonRepositoryTest repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<Person> GetAll()
        {
            if (_index is null)
            {
                _index = _repository.GetAll();
            }
            return _index;

        }
    }
}
