Feature: Test Login Scenarios

This feature file includes the different variations for login and expected messages from the platform.

@UC1
Scenario: UC1 Login with empty credentials but clearing the input fields
	Given A user is using the "<browser>" browser
	And The user clears the username field
	And The user clears the password field
	When The user clicks the Login button
	Then The application should display the error message: Username is required
Examples:
      | browser |
      | chrome  |
      | edge    |


@UC2
Scenario: UC2 Login by passign only the username
	Given A user is using the "<browser>" browser
	And The user types any credentials into the username field
	When The user clicks the Login button
	Then The application should display the error message: Password is required
Examples:
      | browser |
      | chrome  |
      | edge    |

@UC3
Scenario: UC3 Login by passign Username and Password
	Given A user is using the "<browser>" browser
	And The user types a valid "<username>" into the username field
	And The user types a valid "<password>" into the password field
	When The user clicks the Login button
	Then The application should lead the user to the dashboard page with the title: Swag Labs
Examples:
      |browser |username	  |password     | 
      |chrome  |standard_user |secret_sauce |
      |chrome  |visual_user   |secret_sauce |
	  |edge    |standard_user |secret_sauce |
      |edge    |visual_user   |secret_sauce |