#pragma once
#ifndef UNMANAGED_GLOBAL_H
#define UNMANAGED_GLOBAL_H



#ifdef UNMANAGED_EXPORTS
# define UNMANAGED_EXPORTDLL extern "C" __declspec( dllexport )
#else
# define UNMANAGED_EXPORTDLL extern "C" __declspec( dllimport )
#endif

#endif // UNMANAGED_GLOBAL_H