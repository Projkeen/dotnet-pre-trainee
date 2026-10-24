using Refactor_Bad_Code;
using System;
using System.Collections.Generic;

var userService = new UserService(new UserRepository(), new UserValidation(), new List<INotificationSender>
        {
        new EmailNotificationSender(),
        new SmsNotificationSender(),
        new PushNotificationSender()        
        },
        new Logging());

userService.RegisterUser(1, "Anna", "anna@example.com", "email");
userService.RegisterUser(2, "Christopher", "christopher@example.com", "sms");
userService.UpdateEmail(1, "anna.new@example.com");
userService.PrintAllUsers();
