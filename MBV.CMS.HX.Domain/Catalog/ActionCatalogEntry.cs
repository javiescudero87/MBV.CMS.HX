using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBV.CMS.HX.Domain.Catalog
{
    public class ActionCatalogEntry
    {
        public string Name { get; set; }
        public Type Action { get; set; }

        public ActionCatalogEntry(string name, Type action)
        {
            Name = name;
            Action = action;
        }

        public Type SubjectType 
        { 
            get
            {
                return GetGenericType(Action).GenericTypeArguments[0];
            } 
        }

        public Type CreateDto
        {
            get
            {
                return GetGenericType(Action).GenericTypeArguments[1];
            }
        }

        public Type ExecuteDto
        {
            get
            {
                return GetGenericType(Action).GenericTypeArguments[2];
            }
        }

        public Type VerifyDto
        {
            get
            {
                return GetGenericType(Action).GenericTypeArguments[3];
            }
        }

        private Type GetGenericType(Type action)
        {
            if (action.IsGenericType)
                return action;
            return GetGenericType(action.BaseType);
        }
    }
}
