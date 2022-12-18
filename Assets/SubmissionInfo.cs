
// This class contains metadata for your submission. It plugs into some of our
// grading tools to extract your game/team details. Ensure all Gradescope tests
// pass when submitting, as these do some basic checks of this file.
public static class SubmissionInfo
{
    // TASK: Fill out all team + team member details below by replacing the
    // content of the strings. Also ensure you read the specification carefully
    // for extra details related to use of this file.

    // URL to your group's project 2 repository on GitHub.
    public static readonly string RepoURL = "https://github.com/COMP30019/project-2-squirrel-squad";
    
    // Come up with a team name below (plain text, no more than 50 chars).
    public static readonly string TeamName = "Squirrel Squad";
    
    // List every team member below. Ensure student names/emails match official
    // UniMelb records exactly (e.g. avoid nicknames or aliases).
    public static readonly TeamMember[] Team = new[]
    {
        new TeamMember("Bruce Zhu", "yiczhu@student.unimelb.edu.au"),
        new TeamMember("Tao Yu", "ty2@student.unimelb.edu.au"),
        new TeamMember("ZhikaiWu", "zhikaiw1@student.unimelb.edu.au"),
        new TeamMember("Zilun Li", "zilunl@student.unimelb.edu.au"), 
    };

    // This may be a "working title" to begin with, but ensure it is final by
    // the video milestone deadline (plain text, no more than 50 chars).
    public static readonly string GameName = "Save: The Forest";

    // Write a brief blurb of your game, no more than 200 words. Again, ensure
    // this is final by the video milestone deadline.
    public static readonly string GameBlurb = 
    @"
    Background:
    The forest has been polluted due to the ongoing industrialisation and 
    the “Heart of The Forest” thereby has lost its vitality to support the thousands of lives residing in the forest. 
    To revive the heart of the forest, the warrior of the forest, Fox, decided to take the role.

    The player will need to control the fox and pass through different levels based on three different themes to 
    collect the elements of “Wood”, “Water” and “Soil” to revive the “Heart of The Forest”. 
    The player would be able to control the fox's movement and interact with the objects in the game. 

    GamePlay:
    The player will press “A” and “D” to control the horizontal movement of the fox, press SPACE to jump,
    and click on the mouse to shoot.    
    ";
    
    // By the gameplay video milestone deadline this should be a direct link
    // to a YouTube video upload containing your video. Ensure "Made for kids"
    // is turned off in the video settings. 
    public static readonly string GameplayVideo = "https://youtu.be/wKx-X8AGKSk";
    
    // No more info to fill out!
    // Please don't modify anything below here.
    public readonly struct TeamMember
    {
        public TeamMember(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public string Email { get; }
    }
}
