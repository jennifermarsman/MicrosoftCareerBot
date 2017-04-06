# Microsoft Career Bot
If you have ever represented Microsoft at a career fair, you know that prospective job candidates tend to ask the same questions: around benefits, locations, roles, education/work experience requirements, etc.  Wouldn’t it be fabulous to have a way to automate responses to some of these common questions, as well as introduce potential job candidates to the power of the technology that we build here at Microsoft?  Enter the Microsoft Career Bot!  This is a tool that can be used by recruiters, evangelists, or anyone else at career fairs, universities, and large events like the Grace Hopper Celebration of Women in Computing.  Students can text the bot to entertain and inform themselves while they are waiting in line to talk to their Microsoft representative, or text it afterwards if they think of further questions. 
 
Try asking things like:
+ Help I have an interview!!!!
+ Can I work for Microsoft from England?
+ If I’m from New Zealand, do I need a work visa?  
 
# Setup
After you grab a copy of this code, you will need to modify the following before running:
+ Go to http://luis.ai and sign in/create an account.  Then select "Import App" and import from the Application JSON file in LuisModels/MicrosoftCareerBot.json.  
+ Then click into the new LUIS app that you just created.  Train and publish the app.  Capture the App Id and the subscription key.  
+ Update the MicrosoftCareerBot/CareerLuisDialog.cs file.  Replace the "TODO-modelID" with the LUIS App Id and "TODO-subscriptionID" with the LUIS endpoint key.  
+ Navigate to https://dev.botframework.com/ and click "Register a Bot".  Capture the bot name and the Microsoft App ID and password that are generated.  
+ Update MicrosoftCareerBot/Web.config with these values.  
