namespace HabitFY_API.Models
{
    /* RG:
     * This is used for the users to fill the analysis relevant information.
     * Don't ever put anything sensitive. I don't want to get sued for dat.
     * */
    public class UserProfile
    {
        
        // Reminder:
        // RG: Frontend people -> while you sending the token, also send the user_id over.
        // This is the ID from the AWS hash Cognito ID pool
        // Which should be attached to the req.header 
        public required string Id {  get; set; }

        // Reminder:
        // RG to Frontend -> https://cihr-irsc.gc.ca/e/48642.html
        // Give the user a description about what is sex so beofre they got offended.
        // Like They click on it. Then they can read the article themselves before they accuse us
        public required string Sex { get; set; }

        public required string Province { get; set; }

        public required string City { get; set; }

        public required string PostalCode { get; set; }

        public required int Age {  get; set; }



        // RG: Nullable because when the profile firstly made
        // They haven't had anything to track yet
        // In the future, user can have one or multiple goals. 
        public ICollection<Goal>? Goals { get; set; }
    }
}
