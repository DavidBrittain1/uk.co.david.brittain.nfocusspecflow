@Golden @GUI
Feature: Google2

A short summary of the feature


Scenario: Search Google for DavidBrit
	Given i am on the Google Homepage
	When I search for 'DavidBrit'
	Then 'DavidBrit' is the top result

@ignore
Scenario Outline: Search Google for multiple things
	Given Google is open
	When I search for '<searchTerm>'
	Then '<searchResult>' is the top result

Examples:
	| searchTerm             | searchResult       |
	| Chess with DavidBrit   | Chess with David   |
	| Cooking with DavidBrit | Cooking with David |

Scenario: Checking multiple results
	Given Google is open
	When I search for 'DavidBrit'
	Then I see in the results
		| url                                                                                                                                                                                         | title
		| DavidBrit - YouTube\nhttps://www.youtube.com > channel\n(Tutorial) Setting up a controller for a game/Add a non-steam game to your steam library · DavidBrit. DavidBrit. 30 views2 years ago. | DavidBrit - YouTube
		| davidbrit - Twitch https://www.twitch.tv › davidbrit                                                                                                                                      | davidbrit - Twitch

