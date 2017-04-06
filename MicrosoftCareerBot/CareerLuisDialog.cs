using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;

namespace MicrosoftCareerBot
{
    [LuisModel("TODO-modelID", "TODO-subscriptionID")]
    [Serializable]
    public class CareerLuisDialog : LuisDialog<object>
    {
        // TODO: move to config file?
        // TODO: default to false
        bool mlSpecific = true;

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = "Hmmmm, I didn't understand that.  I'm still learning!  You can ask me about job locations, diversity in hiring, benefits, preparing for your interview, and more.  You can also contact a recruiter directly at mlrecruiting@microsoft.com.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Benefits")]
        public async Task Benefits(IDialogContext context, LuisResult result)
        {
            string message = "Microsoft is widely recognized as a leading company for offering one of the strongest and most comprehensive compensation and benefits packages in the country. We start with competitive pay, bonuses, and stock awards to eligible employees based on individual performance. We offer industry-leading health coverage including vision, dental, and a 24-hour health hotline.  New birth mothers receive 8 weeks of paid maternity disability leave, and any new parents (including adoptive parents or foster placements) receive an additional 12 weeks of fully paid parental leave to bond with their new family.  We have a 401(k) plan with matching and employee stock purchase plan.  We give tuition and textbook reimbursement for approved work-related courses.  Employees receive 15 paid vacation days, 10 paid sick-leave days, and 10 paid U.S. holidays, plus two personal days to call your own each year.  Finally, we add on unique offerings that might surprise you, like volunteer time and gift matching, gym and fitness money, on-campus kitchens, and flexible work hours.  Learn more at https://careers.microsoft.com/benefits.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("EducationWorkExperience")]
        public async Task EducationWorkExperience(IDialogContext context, LuisResult result)
        {
            string message = null;
            if (mlSpecific)     
                message = "There are many people with diverse educational and industry experience that work at Microsoft.  To learn more, visit http://blogs.microsoft.com/jobs/why-a-machine-learning-job-at-microsoft-means-the-chance-to-try-amazing-things/.";
            else
                message = "There are many people with diverse educational and industry experience that work at Microsoft.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("MicrosoftResearchJobs")]
        public async Task MicrosoftResearchJobs(IDialogContext context, LuisResult result)
        {
            string message = "A brilliant team of researchers are working to solve technology’s most exciting challenges.  Working in research at Microsoft, you’ll have the opportunity, resources, and support to work on meaningful projects within and across disciplines.  To learn more about jobs in Microsoft Research, visit https://www.microsoft.com/en-us/research/careers/.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("InterviewPrep")]
        public async Task InterviewPrep(IDialogContext context, LuisResult result)
        {
            string message = "We have listed some interview tips at https://careers.microsoft.com/help/interview.  Good luck!";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Roles")]
        public async Task Roles(IDialogContext context, LuisResult result)
        {
            string message = null;
            if (mlSpecific)
                message = "We have several opportunities to do Machine Learning work at Microsoft, including the roles of Applied Scientist, Data Scientist, Machine Learning Scientist, Machine Learning Engineer, Machine Learning Researcher, Research Software Development Engineer, and some Program Manager, Solution Architect, Evangelist, and Consulting Services positions.";
            else
                message = "There are many roles available at Microsoft: engineering, business, consulting, content publishing, customer service, data science, development, evangelism, finance, hardware engineering, human resources, operations, legal, marketing, product planning, program management, research, sales, services, testing, and user experience.  Search for your ideal position at https://careers.microsoft.com/search.aspx.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("RecruiterContact")]
        public async Task RecruiterContact(IDialogContext context, LuisResult result)
        {
            string message = "You can contact a recruiter at mlrecruiting@microsoft.com.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("DataScienceSkills")]
        public async Task DataScienceSkills(IDialogContext context, LuisResult result)
        {
            string message = "There are multiple ways to increase your data science skills.  In the summer of 2016, we introduced the Microsoft Professional Degree in Data Science.  The Microsoft Professional Degree Program will provide hand-on labs with the latest tools, increase your data science knowledge and skills, and will also provide discussion groups, teaching assistants, and expert instructors to help get your tough questions answered.  With the Microsoft Professional Degree Program, learning online doesn’t mean learning alone. Learn more at https://academy.microsoft.com/en-US/professional-degree/data-science/.  Another way to hone your Data Science and Analytics expertise is to participate in a Cortana Intelligence Competition!  Learn more at https://gallery.cortanaintelligence.com/competitions.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("MicrosoftNews")]
        public async Task MicrosoftNews(IDialogContext context, LuisResult result)
        {
            string message = null;
            if (mlSpecific)
                message = "To keep up to date on the latest Microsoft machine learning news, follow @MLatMSFT on Twitter.  You can view Microsoft machine learning videos, including demos and interviews, on http://channel9.msdn.com.  Finally, check out our Cortana Intelligence and Machine Learning blog at https://blogs.technet.microsoft.com/machinelearning/.";
            else
                // TODO
                message = "TODO";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("InternalCommunities")]
        public async Task InternalCommunities(IDialogContext context, LuisResult result)
        {
            string message = null;
            if (mlSpecific)
                message = "The internal Microsoft Machine Learning community is very strong.  We have close to 5,000 employees from all over the globe that are members of the Microsoft Machine Learning Community.  We utilize our Yammer service to post ML related questions, promote cross-group collaborations and more.  Many employees participate in quarterly machine learning hackathons and attend twice yearly internal machine learning, analytics, and data science conferences that are held in Redmond, called MLADS. Because of the tremendous increase of Machine Learning interest, we are expanding our internal conference presence and, for the first time, will host MLADS in Bangalore, India in early August 2016.";
            else
                // TODO
                message = "TODO";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Diversity")]
        public async Task Diversity(IDialogContext context, LuisResult result)
        {
            string message = "Microsoft is passionately committed to diversity.  We strive to create an environment that helps Microsoft capitalize on the diversity of its people and the inclusion of ideas and solutions to meet the needs of its increasingly global and diverse customer base.  Learn more and view our workforce demographics at https://www.microsoft.com/en-us/diversity/default.aspx.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Locations")]
        public async Task Locations(IDialogContext context, LuisResult result)
        {
            string message = null;
            if (mlSpecific)
                message = "Machine learning work at Microsoft happens at a global level.  Some of the locations performing machine learning work are Washington, California, Massachusetts, New York, China, Singapore, Germany, England, Mexico, Chile, Columbia, India, and Israel.  You can search for jobs by location at https://careers.microsoft.com/search.aspx.";
            else
                message = "Microsoft has offices all over the world.  You can search for jobs by location at https://careers.microsoft.com/search.aspx.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Visas")]
        public async Task Visas(IDialogContext context, LuisResult result)
        {
            string message = "All non-U.S. residents require a U.S. work visa (H1B). If you receive an offer from Microsoft, we will cover all costs for visa processing and approval. There are many jobs for which the company might be able to sponsor visas, depending on the requirements of the job and the qualifications of the candidate. We currently have many employees who are foreign nationals. Please feel free to apply to any jobs you think you are qualified for, and if the role is appropriate for foreign nationals and you are qualified for the job, you will hear from the recruiter to proceed with the interview process and visa evaluation.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Compensation")]
        public async Task Compensation(IDialogContext context, LuisResult result)
        {
            string message = "We pay well.  :)  Microsoft is widely recognized as a leading company for offering one of the strongest and most comprehensive compensation and benefits packages in the country. We start with competitive pay, bonuses, and stock awards to eligible employees based on performance. Then, we add on unique offerings that might surprise you.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Relocation")]
        public async Task Relocation(IDialogContext context, LuisResult result)
        {
            string message = "We offer everyone two options: A full relocation package that handles every detail — from movers packing up your house or dorm, moving your car, your pet, and paying for 100 percent of your travel expenses. It makes the move seamless. We also give people the opportunity to take a lump sum stipend for relocation. For some new graduates, that makes more sense. They can move themselves and use the money to help them get settled. We cover the same applicable expenses for our interns.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

    }
}