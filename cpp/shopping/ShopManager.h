#ifndef _SHOPMANAGER_H_
#define _SHOPMANAGER_H_

#include "Common.h"

//void CashierWorker(TPtrCashier ca);

class ShopManager {

public:
  ShopManager();
  ~ShopManager();

  void Add(TPtrCustomer c);
  void Run(struct tm now);

private:
  bool isRunning;
  TCashierVec cashiers;
  //TThreadVec threads;

  //void CashierWorker(TPtrCashier ca);
};

#endif
