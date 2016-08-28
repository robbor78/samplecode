#ifndef _SHOPQUEUE_H_
#define _SHOPQUEUE_H_

#include <mutex>
#include "Common.h"

using namespace std;



class ShopQueue {

public:
  ShopQueue();
  ~ShopQueue();

  TQueue::size_type GetLength();

  void Add(TPtrCustomer c);
  TPtrCustomer Process();

private:
  TQueue q;
  mutex mtx;

};

#endif
