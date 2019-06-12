using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    /*
     -AbstractFactory  (AbstractFactoryProfile)
            declares an interface for operations that create abstract products
     -ConcreteFactory   (University, HighSchool, Hospital)
            implements the operations to create concrete product objects
     -AbstractProduct   (Learner, Coach)
            declares an interface for a type of product object
     -Product  (UniversityTeacher, UniversityGraduating, HighSchoolTeacher, HighSchoolGraduating, Doctor,Assistant)
            defines a product object to be created by the corresponding concrete factory
            implements the AbstractProduct interface
     -Client  (Community)
            uses interfaces declared by AbstractFactory and AbstractProduct classes
    */

    /// <summary>
    /// Main Class to simulate Abstract Factory Profile
    /// (Profiles: Academic and Professional)
    /// </summary>
    abstract class AbstractFactoryProfile
    {
        public abstract Learner CreateLearner();
        public abstract Coach CreateCoach();
    }


    /// <summary>
    /// The 'Concrete Factory Environment 1' class
    /// </summary>
    class University : AbstractFactoryProfile
    {
        public override Coach CreateCoach()
        {
            return new UniversityTeacher();
        }

        public override Learner CreateLearner()
        {
            return new UniversityGraduating();
        }
    }

    /// <summary>
    /// The 'Concrete Factory Environment 2' class
    /// </summary>
    class HighSchool : AbstractFactoryProfile
    {
        public override Coach CreateCoach()
        {
            return new HighSchoolTeacher();
        }

        public override Learner CreateLearner()
        {
            return new HighSchoolGraduating();
        }
    }

    /// <summary>
    /// The 'Concrete Factory Environment 3' class
    /// </summary>
    class Hospital : AbstractFactoryProfile
    {
        public override Coach CreateCoach()
        {
            return new Doctor();
        }

        public override Learner CreateLearner()
        {
            return new Assistant();
        }
    }


    /// <summary>
    /// The 'Abstract Profile A' abstract class
    /// </summary>
    abstract class Learner
    {
    }

    /// <summary>
    /// The 'Abstract Profile B' abstract class
    /// </summary>
    abstract class Coach
    {
        public abstract void Train(Learner s);
    }

    /// <summary>
    /// The 'Profile A1' class
    /// </summary>
    class UniversityGraduating : Learner
    {

    }

    /// <summary>
    /// The 'Profile B1' class
    /// </summary>
    class UniversityTeacher : Coach
    {
        public override void Train(Learner s)
        {
            Console.WriteLine(this.GetType().Name +
        " teaches " + s.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Profile A2' class
    /// </summary>
    class HighSchoolGraduating : Learner
    {

    }

    /// <summary>
    /// The 'Profile B2' class
    /// </summary>
    class HighSchoolTeacher : Coach
    {
        public override void Train(Learner s)
        {
            Console.WriteLine(this.GetType().Name +
        " teaches " + s.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Profile A3' class
    /// </summary>
    class Assistant : Learner { }

    /// <summary>
    /// The 'Profile B3' class
    /// </summary>
    class Doctor : Coach
    {
        public override void Train(Learner s)
        {
            Console.WriteLine(this.GetType().Name +
        " coach " + s.GetType().Name);
        }
    }

    

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class Community
    {
        private Coach _coach;
        private Learner _learner;

        // Constructor
        public Community(AbstractFactoryProfile factory)
        {
            _coach = factory.CreateCoach();
            _learner = factory.CreateLearner();
        }

        public void RunActivities()
        {
            _coach.Train(_learner);
        }
    }

}
