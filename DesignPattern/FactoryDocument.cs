using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    /*
     -Product  (Page)
        defines the interface of objects the factory method creates
     -ConcreteProduct  (SkillsPage, EducationPage, ExperiencePage)
        implements the Product interface
     -Creator  (FactoryDocument)
        declares the factory method, which returns an object of type Product. 
        Creator may also define a default implementation of the factory method that 
        returns a default ConcreteProduct object.
        may call the factory method to create a Product object.
     -ConcreteCreator  (Report, Resume)
        overrides the factory method to return an instance of a ConcreteProduct.
     */

    /// <summary>
    /// Main Class to simulate Factory Method Document
    /// (Documents: Report and Resume)
    /// </summary>
    abstract class FactoryDocument
    {
        private List<Page> _pages = new List<Page>();

        // Constructor calls abstract Factory method
        public FactoryDocument()
        {
            this.CreatePages();
        }

        public List<Page> Pages
        {
            get { return _pages; }
        }

        // Factory Method
        public abstract void CreatePages();
    }

    /// <summary>
    /// A 'Concrete Document Creator' class
    /// </summary>
    class Resume : FactoryDocument
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    /// <summary>
    /// A 'Concrete Document Creator' class
    /// </summary>
    class Report : FactoryDocument
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }

    /// <summary>
    /// The 'Page' abstract class
    /// </summary>
    abstract class Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class SkillsPage : Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class EducationPage : Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class ExperiencePage : Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class IntroductionPage : Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class ResultsPage : Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class ConclusionPage : Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class SummaryPage : Page
    {
    }

    /// <summary>
    /// A 'Concrete Page' class
    /// </summary>
    class BibliographyPage : Page
    {
    }
}
