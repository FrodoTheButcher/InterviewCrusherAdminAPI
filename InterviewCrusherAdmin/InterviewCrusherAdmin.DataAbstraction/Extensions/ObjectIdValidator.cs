using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusherAdmin.DataAbstraction.Extensions
{
  public static class ObjectIdValidator
  {
    public static bool IsValidObjectId(this string Id)
    {
      return ObjectId.TryParse(Id, out _);
    }
  }
}
