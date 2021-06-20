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
        //png image as base64 string
        public string Image { 
            get { if(image==null){
                    //if no image, show image with text 'no picture'
                    return "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";
                }else{
                    return image;
                }
                } 
            set => image = value; }
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

        public Sim FindUltimateAncestor()
        {
            return FindUltimateAncestorStep().ancestor;
        }

        public (int index,Sim ancestor) FindUltimateAncestorStep()
        {
            int i=0;
            int j=0;
            Sim ancestorA = null;
            Sim ancestorB = null;
            if (ParentA != null)
            {
                var result = ParentA.FindUltimateAncestorStep();
                i = result.index+1;
                ancestorA = result.ancestor;
            }                    
            if (ParentB != null)
            {
                var result = ParentB.FindUltimateAncestorStep();
                j = result.index + 1;
                ancestorB = result.ancestor;
            }
            if (ParentA == null & ParentB == null)
            {
                return (0, this);
            }

            if (i < j)
            {
                return (j, ancestorB);
            }
            else
            {
                return (i, ancestorA);
            }


        }

        public string ConvertUltimateAncestorToHTML()
        {
            return FindUltimateAncestor().ConvertToHTML();
        }

        public string ConvertToHTML()
        {
            return "<form id=\"FamilyTreeForm\"><div class=\"tree\" id=\"FamilyTreeDiv\"><ul>" + ConvertNodeToHTML() + "</ul></div></form>";
        }
        public string ConvertNodeToHTML()
        {
            string html = "<li><div class=\"familynode\"><span class=\"" + Gender.ToLower() + "\">" + "<figure><img class=\"img-thumbnail\" src=\"data:image/png;base64, " + Image+"\" /><figcaption>"+FullName + "</figcaption></figure></span>";
            if (Spouse == null)
            {
                html += "</div>";
            }else
            {
                html += "<span class=\"spacer\"></span>";
                html += "<span class=\"" + Spouse.Gender.ToLower() + "\">" + "<figure><img class=\"img-thumbnail\" src=\"data:image/png;base64, " + Spouse.Image + "\" /><figcaption>" + Spouse.FullName + "</figcaption></figure></span>";
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
