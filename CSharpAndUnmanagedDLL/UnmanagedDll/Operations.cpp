#include "unmanaged_global.h"



UNMANAGED_EXPORTDLL int add(int a, int b)
{
	return a+b;
}

UNMANAGED_EXPORTDLL int subtract(int a, int b)
{
	return a-b;
}

UNMANAGED_EXPORTDLL int mult(int a, int b)
{
	return a * b;
}

UNMANAGED_EXPORTDLL int div(int a, int b)
{
	return b>0? (a/b):(b/a);
}

