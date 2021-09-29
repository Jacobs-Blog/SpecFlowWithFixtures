Feature: ListBreweries
	As a beer lover 
	I want to browse through a list of breweries
	So I can search for new beers to try

Scenario: Listing breweries
	Given I open the application
	When opening the list page
	Then a list of breweries should be available