using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * STUDENT NAME:AVIJIT BAGCHI
 * STUDENT ID: BAGCHI
 * DESCRIPTION: This is the main form for the application
 * Version: 1.1
 */

namespace COMP123_S2019_FinalTestC.Views
{
    public partial class CharacterGenerationForm : COMP123_S2019_FinalTestC.Views.MasterForm
    {
        static Random random = new Random();
        public CharacterGenerationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        //Identity Page
        private void NextButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            GenerateNames();
            Program.character.Identity.FirstName = FirstNameDataLabel.Text;
            Program.character.Identity.LastName = LastNameDataLabel.Text;
        }

        List<string> FirstNameList = new List<string>();
        List<string> LastNameList = new List<string>();
        public void LoadNames()
        {
            FirstNameList = new List<string>(File.ReadAllLines("firstNames.txt"));
            LastNameList = new List<string>(File.ReadAllLines("lastNames.txt"));
        }
        public void GenerateNames()
        {
            LoadNames();
            string firstName = FirstNameList[random.Next(FirstNameList.Count)];
            string lastName = LastNameList[random.Next(LastNameList.Count)];
            string firstNameValue = firstName.ToString();
            string lastNameValue = lastName.ToString();
            FirstNameDataLabel.Text = firstName;
            LastNameDataLabel.Text = lastName;
            //return firstNameValue + " " + lastNameValue;
            //CharacterNameTextBox.Text = firstNameValue + " " + lastNameValue;
        }

        //Ability Page
        public void GenerateAbilities()
        {
            int[] abilities = new int[6];
            int strengthValue = random.Next(1, 15);
            int dexterityValue = random.Next(1, 15);
            int enduranceValue = random.Next(1, 15);
            int intellectValue = random.Next(1, 15);
            int educationValue = random.Next(1, 15);
            int socialStandingValue = random.Next(1, 15);
            //storing values in container class
            Program.character.Strength = strengthValue.ToString();
            Program.character.Dexterity = dexterityValue.ToString();
            Program.character.Endurance = enduranceValue.ToString();
            Program.character.Intellect = educationValue.ToString();
            Program.character.Education = educationValue.ToString();
            Program.character.SocialStanding = socialStandingValue.ToString();
            //Displaying the abilities

            StrengthDataLabel.Text = Program.character.Strength;
            DexterityDataLabel.Text = Program.character.Dexterity;
            EnduranceDataLabel.Text = Program.character.Endurance;
            IntellectDataLabel.Text = Program.character.Intellect;
            EducationDataLabel.Text = Program.character.Education;
            SocialStandingDataLabel.Text = Program.character.SocialStanding;
        }

        List<string> SkillList = new List<string>();
        public void LoadSkills()
        {
            SkillList = new List<string>(File.ReadAllLines("skills.txt"));
        }
        private void CharacterGenerationForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
            LoadSkills();
        }

        public void GenerateRandomSkills()
        {
            string firstAbility = SkillList[random.Next(SkillList.Count)];
            string secondAbility = SkillList[random.Next(SkillList.Count)];
            string thirdAbility = SkillList[random.Next(SkillList.Count)];
            string fourthAbility = SkillList[random.Next(SkillList.Count)];
        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            GenerateAbilities();
        }
    }
}
