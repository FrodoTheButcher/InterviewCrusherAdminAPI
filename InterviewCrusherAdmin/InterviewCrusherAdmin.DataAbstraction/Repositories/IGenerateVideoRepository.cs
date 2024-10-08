using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusherAdmin.DataAbstraction.Repositories
{
  public interface IGenerateVideoRepository<T> : IRepository<T>
    where T : IDatabaseEntityRepresentation
  {
  }
}
