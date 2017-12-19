# Cognitive Banking Bot

This is a chatbot created to provide an conversational interface for banking services. That chatbot processes incoming commands from a user and converts them into messages that are then sent to a bankend system that processes these user commands.

## User Requests
Some basic commands are,

- Transactions
  - Balance Inquiry
  - Funds Transfer
- Domain Queries
  - Nearest ATM
  - Banking Products
  - Cash Flow Analysis

## Architecture
![Bot Architecture](https://ankitbko.github.io/assets/images/posts/mebot-1/BotArch.png)
![LUIS](https://msdnshared.blob.core.windows.net/media/2017/09/Typical-Bot-Architecture-Diagram.png)
![LUIS](https://microsoft.github.io/techcasestudies/images/powel/CaaP/architecture.jpg)
![Bot Architecture](https://msdnshared.blob.core.windows.net/media/2016/11/freddyarchitecture2.jpg)


## Deployment


1. Develop chatbot application
2. Test with emulator
3. Deploy through VS 2017 publish feature
4. Make sure the keys are correct
5. Register to Bot Framework https://dev.botframework.com
6. Integrate with channels

Test with Emulator:
1. Download emulator from https://github.com/Microsoft/BotFramework-Emulator/releases
2. Run bot
3. Put in the URL on emulator. Skip the ID and Key fields for now
4. Click on Connect


Deploy through VS 2017 publish feature
1. Register application on https://apps.dev.microsoft.com
2. Paste the generated ID and Key in Web.Config. (Web.Config keys MicrosoftAppId, MicrosoftAppPassword).
3. Publish application through VS 2017.
4. Make a note of the Site URL from Publish Profile.

Test deployment with Emulator:
1. Use the Site URL from Publish Profile.
2. Use the MicrosoftAppId and MicrosoftAppPassword. Click Connect.
