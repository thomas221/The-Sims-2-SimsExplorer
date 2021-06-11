using FileHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Sims_2_SimsExplorer.Models
{
    [DelimitedRecord(","), IgnoreFirst(1)]
    public class Sim
    {
        private string hood;
        [FieldQuoted]
        private string hoodName;
        private string nID;
        [FieldQuoted]
        private string firstName;
        [FieldQuoted]
        private string lastName;
        [FieldQuoted]
        private string simDescription;
        private string familyInstance;
        [FieldQuoted]
        private string householdName;
        private string houseNumber;
        private string availableCharacterData;
        private string unlinked;
        private string parentA;
        [FieldHidden]
        private Sim parentASim;
        private string parentB;
        [FieldHidden]
        private Sim parentBSim;
        private string spouse;
        [FieldHidden]
        private Sim spouseSim;
        private string bodyType;
        private string nPCType;
        private string schoolType;
        private string grade;
        private string careerPerformance;
        private string career;
        private string careerLevel;
        private string zodiacSign;
        private string aspiration;
        private string gender;
        private string lifeSection;
        private string ageDaysLeft;
        private string prevAgeDays;
        private string ageDuration;
        private string blizLifelinePoints;
        private string lifelinePoints;
        private string lifelineScore;
        private string genActive;
        private string genNeat;
        private string genNice;
        private string genOutgoing;
        private string genPlayful;
        private string active;
        private string neat;
        private string nice;
        private string outgoing;
        private string playful;
        private string animals;
        private string crime;
        private string culture;
        private string entertainment;
        private string environment;
        private string fashion;
        private string femalePreference;
        private string food;
        private string health;
        private string malePreference;
        private string money;
        private string paranormal;
        private string politics;
        private string school;
        private string scifi;
        private string sport;
        private string toys;
        private string travel;
        private string weather;
        private string work;
        private string body;
        private string charisma;
        private string cleaning;
        private string cooking;
        private string creativity;
        private string fatness;
        private string logic;
        private string mechanical;
        private string romance;
        private string isAtUniversity;
        private string uniEffort;
        private string uniGrade;
        private string uniTime;
        private string uniSemester;
        private string uniInfluence;
        private string uniMajor;
        private string species;
        private string salary;
        private string primaryAspiration;
        private string secondaryAspiration;
        private string hobbyPredestined;
        private string lifetimeWant;
        [FieldHidden]
        private string image;
        [FieldHidden]
        private List<Sim> parentAChildren = new List<Sim>();
        [FieldHidden]
        private List<Sim> parentBChildren = new List<Sim>();
        [FieldHidden]
        private Sim spouseReverse;

        public string Hood { get => hood; set => hood = value; }
        public string HoodName { get => hoodName; set => hoodName = value; }
        [Key]
        public string SimId { get => nID; set => nID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string SimDescription { get => simDescription; set => simDescription = value; }
        public string FamilyInstance { get => familyInstance; set => familyInstance = value; }
        public string HouseholdName { get => householdName; set => householdName = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string AvailableCharacterData { get => availableCharacterData; set => availableCharacterData = value; }
        public string ParentAId { get => parentA; set => parentA = value; }
        public string ParentBId { get => parentB; set => parentB = value; }
        public string SpouseId { get => spouse; set => spouse = value; }
        public string Unlinked { get => unlinked; set => unlinked = value; }
       
        public string BodyType { get => bodyType; set => bodyType = value; }
        public string NPCType { get => nPCType; set => nPCType = value; }
        public string SchoolType { get => schoolType; set => schoolType = value; }
        public string Grade { get => grade; set => grade = value; }
        public string CareerPerformance { get => careerPerformance; set => careerPerformance = value; }
        public string Career { get => career; set => career = value; }
        public string CareerLevel { get => careerLevel; set => careerLevel = value; }
        public string ZodiacSign { get => zodiacSign; set => zodiacSign = value; }
        public string Aspiration { get => aspiration; set => aspiration = value; }
        public string Gender { get => gender; set => gender = value; }
        public string LifeSection { get => lifeSection; set => lifeSection = value; }
        public string AgeDaysLeft { get => ageDaysLeft; set => ageDaysLeft = value; }
        public string PrevAgeDays { get => prevAgeDays; set => prevAgeDays = value; }
        public string AgeDuration { get => ageDuration; set => ageDuration = value; }
        public string BlizLifelinePoints { get => blizLifelinePoints; set => blizLifelinePoints = value; }
        public string LifelinePoints { get => lifelinePoints; set => lifelinePoints = value; }
        public string LifelineScore { get => lifelineScore; set => lifelineScore = value; }
        public string GenActive { get => genActive; set => genActive = value; }
        public string GenNeat { get => genNeat; set => genNeat = value; }
        public string GenNice { get => genNice; set => genNice = value; }
        public string GenOutgoing { get => genOutgoing; set => genOutgoing = value; }
        public string GenPlayful { get => genPlayful; set => genPlayful = value; }
        public string Active { get => active; set => active = value; }
        public string Neat { get => neat; set => neat = value; }
        public string Nice { get => nice; set => nice = value; }
        public string Outgoing { get => outgoing; set => outgoing = value; }
        public string Playful { get => playful; set => playful = value; }
        public string Animals { get => animals; set => animals = value; }
        public string Crime { get => crime; set => crime = value; }
        public string Culture { get => culture; set => culture = value; }
        public string Entertainment { get => entertainment; set => entertainment = value; }
        public string Environment { get => environment; set => environment = value; }
        public string Fashion { get => fashion; set => fashion = value; }
        public string FemalePreference { get => femalePreference; set => femalePreference = value; }
        public string Food { get => food; set => food = value; }
        public string Health { get => health; set => health = value; }
        public string MalePreference { get => malePreference; set => malePreference = value; }
        public string Money { get => money; set => money = value; }
        public string Paranormal { get => paranormal; set => paranormal = value; }
        public string Politics { get => politics; set => politics = value; }
        public string School { get => school; set => school = value; }
        public string Scifi { get => scifi; set => scifi = value; }
        public string Sport { get => sport; set => sport = value; }
        public string Toys { get => toys; set => toys = value; }
        public string Travel { get => travel; set => travel = value; }
        public string Weather { get => weather; set => weather = value; }
        public string Work { get => work; set => work = value; }
        public string Body { get => body; set => body = value; }
        public string Charisma { get => charisma; set => charisma = value; }
        public string Cleaning { get => cleaning; set => cleaning = value; }
        public string Cooking { get => cooking; set => cooking = value; }
        public string Creativity { get => creativity; set => creativity = value; }
        public string Fatness { get => fatness; set => fatness = value; }
        public string Logic { get => logic; set => logic = value; }
        public string Mechanical { get => mechanical; set => mechanical = value; }
        public string Romance { get => romance; set => romance = value; }
        public string IsAtUniversity { get => isAtUniversity; set => isAtUniversity = value; }
        public string UniEffort { get => uniEffort; set => uniEffort = value; }
        public string UniGrade { get => uniGrade; set => uniGrade = value; }
        public string UniTime { get => uniTime; set => uniTime = value; }
        public string UniSemester { get => uniSemester; set => uniSemester = value; }
        public string UniInfluence { get => uniInfluence; set => uniInfluence = value; }
        public string UniMajor { get => uniMajor; set => uniMajor = value; }
        public string Species { get => species; set => species = value; }
        public string Salary { get => salary; set => salary = value; }
        public string PrimaryAspiration { get => primaryAspiration; set => primaryAspiration = value; }
        public string SecondaryAspiration { get => secondaryAspiration; set => secondaryAspiration = value; }
        public string HobbyPredestined { get => hobbyPredestined; set => hobbyPredestined = value; }
        public string LifetimeWant { get => lifetimeWant; set => lifetimeWant = value; }
        public string Image { get => image; set => image = value; }
        [FieldHidden]
        public virtual Sim ParentA { get => parentASim; set => parentASim = value; }
        [InverseProperty("ParentA")]
        [FieldHidden]
        public virtual List<Sim> ParentAChildren { get => parentAChildren; set => parentAChildren = value; }
        [FieldHidden]
        public virtual Sim ParentB { get => parentBSim; set => parentBSim = value; }
        [InverseProperty("ParentB")]
        [FieldHidden]
        public virtual List<Sim> ParentBChildren { get => parentBChildren; set => parentBChildren = value; }
        [FieldHidden]
        public virtual Sim Spouse { get => spouseSim; set => spouseSim = value; }
        [InverseProperty("Spouse")]
        [FieldHidden]
        public virtual Sim SpouseReverse { get => spouseReverse; set => spouseReverse = value; }
        [FieldHidden]
        public string FullName { get => FirstName + " " + LastName; }
        public virtual List<Sim> Children
        {
            get
            {
                return ParentAChildren.Concat(ParentBChildren).ToList();
            }
        }

        public string ConvertToHTML()
        {
            return "<form id=\"form1\"><div class=\"tree\" id=\"FamilyTreeDiv\"><ul>" + ConvertNodeToHTML() + "</ul></div></form>";
        }
        public string ConvertNodeToHTML()
        {
            string html = "<li><div class=\"familynode\"><span class=\"" + Gender.ToLower() + "\">" + "<figure><img src=\"data:image/png;base64, "+Image+"\" /><figcaption>"+FullName + "</figcaption></figure></span>";
            if (Spouse == null)
            {
                html += "</div>";
            }else
            {
                html += "<span class=\"spacer\"></span>";
                html += "<span class=\"" + Spouse.Gender.ToLower() + "\">" + "<figure><img src=\"data:image/png;base64, " + Spouse.Image + "\" /><figcaption>" + Spouse.FullName + "</figcaption></figure></span>";
            }

            if (Children.Count == 0)
            {
                html += "</li>";
            }
            else
            {
                html += "<ul>";
                foreach (Sim sim in Children)
                {
                    html += sim.ConvertNodeToHTML();
                }

                html += "</ul></li>";
            }

            return html;
        }
    }
}
