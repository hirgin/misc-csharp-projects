while(true)
{
    Console.WriteLine("Enter a password");
    PasswordValidator password = new PasswordValidator(Console.ReadLine());
    password.validatePassword(password.tempPass);
}

class PasswordValidator
{
    public string tempPass;

    public PasswordValidator(string tempPass)
    {
        this.tempPass = tempPass;
    }

    public void validatePassword(string password)
    {
        if(lengthCheck(password) == false)
        { Console.WriteLine("Invalid Password."); return; }
        if (oneCheck(password) == false)
        { Console.WriteLine("Invalid Password."); return; }
        if (charCheck(password) == false)
        { Console.WriteLine("Invalid Password."); return; }
        Console.WriteLine("Valid password!");
      
    }

    bool lengthCheck(string password)
    {
        if(password.Length > 13)
        {   
            Console.WriteLine($"Password is {password.Length} characters and must be less than 13 characters.");
            return false;
        }
        else if(password.Length < 6) 
        {
            Console.WriteLine($"Password is {password.Length} characters and must be more than 6 characters.");
            return false;
        }
        else { return true; }
    }

    bool oneCheck(string password) 
    {
        bool upper , lower , digit;
        upper = lower = digit = false;
        foreach(char c in password) 
        { 
            if(char.IsUpper(c)) 
            { 
                upper = true;
            }
            if(char.IsLower(c))
            {
                lower = true;
            }
            if(char.IsDigit(c))
            {
                digit = true;
            }
        }
        if(upper && lower && digit) { return true; }
        else 
        {
            Console.WriteLine("Passwords must contain at least one uppercase letter, one lowercase letter, and one number.");
            return false; }
        }

    bool charCheck(string password)
    {
        foreach(char c in password)
        {
            if(c == 'T' || c == '&') 
            {
                Console.WriteLine("Passwords cannot contain a capital T or an ampersand (&)");
                return false; 
            }
        }
        return true;
    }



}