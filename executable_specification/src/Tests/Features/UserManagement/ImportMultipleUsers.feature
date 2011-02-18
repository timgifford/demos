Feature: Import Multiple Users
  In order to integrate user from external systems
  As a User Manager
  I need to import multiple users from a file

Scenario: Require last name
  Given a user row:
    | Username | First Name | Last Name |
    | tgifford | Tim        |           |
  When row is imported
  Then validation error should be "Last Name Required"

Scenario: Require first name
  Given a user row:
    | Username | First Name | Last Name |
    | tgifford |            | Gifford   |
  When row is imported
  Then validation error should be "First Name Required"

 Scenario: Require username
   Given a user row:
    | Username | First Name | Last Name |
    |          | Tim        | Gifford   |
  When row is imported
  Then validation error should be "Username Required"


