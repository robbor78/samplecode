#ifndef _CUSTOMERMAKER_H_
#define _CUSTOMERMAKER_H_

#include "Common.h"

class CustomerMaker {

public:
  CustomerMaker(TShopManager sm);

  void Run();

private:
  TShopManager sm;

};

#endif

