using UiPath.CodedWorkflows;

namespace SampleBO
{
    public class CodedTestCase : CodedWorkflow
    {
        [TestCase]
        public void Execute()
        {
            // Arrange
            string email = "nithin@test.com";
            string password = "*******";
            
            //testing.

            // Act
            // To invoke any workflow (XAML or coded), you can use helper methods in CodedWorkflow, e.g. RunWorkflow(...).
            var screen = uiAutomation.Open("Login");
            screen.TypeInto("Email", email);
            screen.TypeInto("Password", password);
            screen.Click("Submit");

            // Assert
            // To start using activities, use IntelliSense (CTRL + Space) to discover the available services, e.g. testing.VerifyExpression(...).
            testing.VerifyExpression(screen.WaitState("UserIcon", null));
        }
    }
}