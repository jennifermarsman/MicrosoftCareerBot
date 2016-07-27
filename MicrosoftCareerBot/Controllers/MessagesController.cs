using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace MicrosoftCareerBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        // TODO: move to config file?
        bool mlSpecific = true;

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                string answer = "Hmmmm, I didn't understand that.  I'm still learning!  You can also contact a recruiter directly at mlrecruiting@microsoft.com.";
                Rootobject luisObj = await LUISClient.ParseUserInput(activity.Text);
                if (luisObj.intents.Count() > 0)
                {
                    switch (luisObj.intents[0].intent)  // assumption: first intent is highest scored
                    {
                        case "Benefits":
                            answer = "Microsoft is widely recognized as a leading company for offering one of the strongest and most comprehensive compensation and benefits packages in the country. We start with competitive pay, bonuses, and stock awards to eligible employees based on individual performance. We offer industry-leading health coverage including vision, dental, and a 24-hour health hotline.  New birth mothers receive 8 weeks of paid maternity disability leave, and any new parents (including adoptive parents or foster placements) receive an additional 12 weeks of fully paid parental leave to bond with their new family.  We have a 401(k) plan with matching and employee stock purchase plan.  We give tuition and textbook reimbursement for approved work-related courses.  Employees receive 15 paid vacation days, 10 paid sick-leave days, and 10 paid U.S. holidays, plus two personal days to call your own each year.  Finally, we add on unique offerings that might surprise you, like volunteer time and gift matching, gym and fitness money, on-campus kitchens, and flexible work hours.  Learn more at https://careers.microsoft.com/benefits.";
                            break;
                        case "EducationWorkExperience":
                            if (mlSpecific)
                                answer = "There are many people with diverse educational and industry experience that do Machine Learning work at Microsoft.  To learn more, visit http://blogs.microsoft.com/jobs/why-a-machine-learning-job-at-microsoft-means-the-chance-to-try-amazing-things/.";
                            else
                                answer = "There are many people with diverse educational and industry experience that work at Microsoft.";
                            break;
                        case "MicrosoftResearchJobs":
                            answer = "A brilliant team of researchers are working to solve technology’s most exciting challenges.  Working in research at Microsoft, you’ll have the opportunity, resources and support to work on meaningful projects within and across disciplines.  To learn more about jobs in Microsoft Research, visit https://www.microsoft.com/en-us/research/careers/.";
                            break;
                        case "InterviewPrep":
                            answer = "We have listed some interview tips at https://careers.microsoft.com/help/interview.  Good luck!";
                            break;
                        case "Roles":
                            if (mlSpecific)
                                answer = "We have several opportunities to do Machine Learning work at Microsoft, including the roles of Applied Scientist, Data Scientist, Machine Learning Scientist, Machine Learning Engineer, Machine Learning Researcher, Research Software Development Engineer, and some Program Manager, Solution Architect, Evangelist, and Consulting Services positions.";
                            else
                                answer = "There are many roles available at Microsoft: engineering, business, consulting, content publishing, customer service, data science, development, evangelism, finance, hardware engineering, human resources, operations, legal, marketing, product planning, program management, research, sales, services, testing, and user experience.  Search for your ideal position at https://careers.microsoft.com/search.aspx.";
                            break;
                        case "RecruiterContact":
                            answer = "You can contact a recruiter at mlrecruiting@microsoft.com.";
                            break;
                        case "DataScienceSkills":
                            answer = "There are multiple ways to increase your data science skills.  In the summer of 2016, we introduced the Microsoft Professional Degree in Data Science.  The Microsoft Professional Degree Program will provide hand-on labs with the latest tools, increase your data science knowledge and skills, and will also provide discussion groups, teaching assistants, and expert instructors to help get your tough questions answered.  With the Microsoft Professional Degree Program, learning online doesn’t mean learning alone. Learn more at https://academy.microsoft.com/en-US/professional-degree/data-science/.  Another way to hone your Data Science and Analytics expertise is to participate in a Cortana Intelligence Competition!  Learn more at https://gallery.cortanaintelligence.com/competitions.";
                            break;
                        case "MicrosoftNews":
                            if (mlSpecific)
                                answer = "To keep up to date on the latest Microsoft machine learning news, follow @MLatMSFT on Twitter.  You can view Microsoft machine learning videos, including demos and interviews, on http://channel9.msdn.com.  Finally, check out our Cortana Intelligence and Machine Learning blog at https://blogs.technet.microsoft.com/machinelearning/.";
                            else
                                // TODO
                                answer = "TODO";
                            break;
                        case "InternalCommunities":
                            if (mlSpecific)
                                answer = "The internal Microsoft Machine Learning community is very strong.  We have close to 5,000 employees from all over the globe that are members of the Microsoft Machine Learning Community.  We utilize our Yammer service to post ML related questions, promote cross-group collaborations and more.  Many employees participate in quarterly machine learning hackathons and attend twice yearly internal machine learning, analytics, and data science conferences that are held in Redmond, called MLADS. Because of the tremendous increase of Machine Learning interest, we are expanding our internal conference presence and, for the first time, will host MLADS in Bangalore, India in early August 2016.";
                            else
                                // TODO
                                answer = "TODO";
                            break;
                        case "Diversity":
                            answer = "Microsoft is passionately committed to diversity.  We strive to create an environment that helps Microsoft capitalize on the diversity of its people and the inclusion of ideas and solutions to meet the needs of its increasingly global and diverse customer base.  Learn more and view our workforce demographics at https://www.microsoft.com/en-us/diversity/default.aspx.";
                            break;
                        case "Locations":
                            if (mlSpecific)
                                answer = "Machine learning work at Microsoft happens at a global level.  Some of the locations performing machine learning work are Washington, California, Massachusetts, New York, China, Singapore, Germany, England, Mexico, Chile, Columbia, India, and Israel.  You can search for jobs by location at https://careers.microsoft.com/search.aspx.";
                            else
                                answer = "Microsoft has offices all over the world.  You can search for jobs by location at https://careers.microsoft.com/search.aspx.";
                            break;
                        case "None":
                            // use default answer, which is set above
                            break;
                    }
                }

                // Return our reply to the user
                //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                Activity reply = activity.CreateReply(answer);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}