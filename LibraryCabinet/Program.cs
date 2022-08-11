// mock UI swap
// if console: call console UI controller
//    console UI controller:
//    wait for Find command -> call FindDocumentCardsByNumber on IStorageManager object
//    stringify the data we got in UI class (in case of console UI), use raw data for output if needed
//    Console.Writeline the results