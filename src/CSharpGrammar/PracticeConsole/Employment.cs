using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Employment
    {


        //  An instance of this class will hold data 
        //  about a person's employment
        //  The code of this class is definition of 
        //  that data.
        //  The characteristics (data) of the class will contain
        //  Title, SUpervisory Level, Years of Employment within
        //  the company

        //  The 4 components of a class definition are:

        //  Data Fields
        //  are storage area in your class.
        //  These are treated as variables.
        //  These maybe public, private, public readonly (access it but not set it), etc.
        private string? _Title;
        private double _Years;


        //  Properties
        //  These are access techiniques to retrive or set data in
        //  your class without directly touching the storage data fields.

        //  Fully implemented property
        //    a) a declared storage area (data field)
        //    b) a declared property signature
        //    c) a coded get "Method"
        //    d) an optional coded set "Method".

        //  When:
        //    a)  If you are storing the associated data in
        //        an explicitly data field.
        //    b)  If you are doing validation against incoming data
        //    c)  Creating a property that generates output from other data sources
        //        wth the class (readonly properties)
        //        ie:  Fullname -> _FirstName + " " + _LastName;

        public string Title
        {
            //  accessor
            //  The get "method" will return the contents of the data field (_Title)
            //  as an expression
            get { return _Title; }
            set
            {
                //  mutator
                //  The set "Method" receives an invoming value
                //    and places it in the associated data field.
                //  During the setting, you might wish to validate the incoming data.
                //  During the setting, you might wish to do some type of loigical
                //   processing using the data to set another field.
                //  The incoming piece of data is referred using the keyword "value"

                //  ensure that the incoming data is not null, empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data");
                }
                //  data is considered valid
                _Title = value;
            }
        }

        //  Auto-implemented property

        //  These properties differ only in syntax.
        //  Each property is responsible for a single piece of data
        //  These properties do NOT reference a declared private data member.
        //  The system generates an internal storage area of the return data type.
        //  The system manages the internal storage for the accessor and mutator.
        //  There is NO additional logic applied to the data value.

        public int Level { get; set; }
        public double Years
            { get { return _Years; } set { _Years = value; } }






        //  Constructor
        //  Behavior (method)


    }
}
