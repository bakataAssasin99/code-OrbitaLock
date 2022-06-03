#ifndef CYRF32_H
#define CYRF32_H

///////////////////////////////////////////////////////////////////////////////
// This function is exported from the CYRF32.dll
long __stdcall WriteCard (char *HotelID, char *cardtype,  char *CardID, char *NormalOpenClose, char *RoomCD, char *CardBeginDateTime, char *CardEndDateTime) ;
long __stdcall ReadCard  (char *HotelID, char *cardtype,  char *CardID, char *NormalOpenClose, char *RoomCD, char *CardBeginDateTime, char *CardEndDateTime) ;

#endif