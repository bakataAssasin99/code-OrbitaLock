
Authorization: Bearer token
ReadCard:

GET


http://localhost:2000/readcard?format=json

WriteCard
POST

http://localhost:2000/writecard?format=json

JSON Template

{ 
  "RoomName":"202",
  "TravellerName":"Dũng",
  "TravellerId":"Nhon",
  "ArrivalDate":"2016-03-29T08:17:21.197Z",
  "DepartureDate":"2016-04-01T08:17:21.197Z",
  "OverrideOldCards":true 
}