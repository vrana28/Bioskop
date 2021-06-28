using System;
using System.Collections.Generic;
using System.Text;
using Bioskop.Podaci;
using Bioskop.Podaci.UnitOfWork;

namespace BusinessLogic
{
    /// <summary>
    /// Represent interface for business logic 
    /// </summary>
    public interface IService
    {

        /// <value>Represent reference to IUnitOfWork</value>
        public IUnitOfWork uow { get; set; }

    }
}
