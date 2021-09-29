Feature: Search Breweries
	As a beer lover
	I want to search for breweries
	So I can plan a visit to a brewery
	
Scenario: Searching for breweries nearby
	Given my current location is "51.6582661,5.279888"
	When searching for breweries closeby
	Then a list of breweries should be returned