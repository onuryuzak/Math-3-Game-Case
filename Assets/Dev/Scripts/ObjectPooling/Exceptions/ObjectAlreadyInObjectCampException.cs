using System;

namespace Base.ObjectPooling.Exceptions
{
    public class ObjectAlreadyInObjectCampException : Exception
    {
        public ObjectAlreadyInObjectCampException(string objectName)
               : base("<b><color=red> " + objectName + " is already in Camp  </color></b> ")
        {

        }
    }
}
