import pandas as pd
import matplotlib.pyplot as plt
from io import StringIO

# Re‑use the CSV snippet you gave. Replace this with open(<path>).read() if you have the file.
csv_raw = """
Method,Job,AnalyzeLaunchVariance,EvaluateOverhead,MaxAbsoluteError,MaxRelativeError,MinInvokeCount,MinIterationTime,OutlierMode,Affinity,EnvironmentVariables,Jit,LargeAddressAware,Platform,PowerPlanMode,Runtime,AllowVeryLargeObjects,Concurrent,CpuGroups,Force,HeapAffinitizeMask,HeapCount,NoAffinitize,RetainVm,Server,Arguments,BuildConfiguration,Clock,EngineFactory,NuGetReferences,Toolchain,IsMutator,InvocationCount,IterationCount,IterationTime,LaunchCount,MaxIterationCount,MaxWarmupIterationCount,MemoryRandomization,MinIterationCount,MinWarmupIterationCount,RunStrategy,UnrollFactor,WarmupCount,Mean,Error,StdDev,Median,Gen0,Gen1,Gen2,Allocated
BuildLinear,DefaultJob,False,Default,Default,Default,Default,Default,Default,1111111111111111,Empty,RyuJit,Default,X64,8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c,.NET 8.0,False,True,False,True,Default,Default,False,False,False,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,16,Default,18.42 ms,0.491 ms,1.449 ms,18.03 ms,1687.5000,1562.5000,968.7500,9.74 MB
BuildBst,DefaultJob,False,Default,Default,Default,Default,Default,Default,1111111111111111,Empty,RyuJit,Default,X64,8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c,.NET 8.0,False,True,False,True,Default,Default,False,False,False,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,16,Default,77.86 ms,1.510 ms,2.166 ms,77.86 ms,2428.5714,1857.1429,1000.0000,13.92 MB
BuildHashSet,DefaultJob,False,Default,Default,Default,Default,Default,Default,1111111111111111,Empty,RyuJit,Default,X64,8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c,.NET 8.0,False,True,False,True,Default,Default,False,False,False,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,16,Default,14.66 ms,0.289 ms,0.658 ms,14.62 ms,1781.2500,1625.0000,1093.7500,10.56 MB
BuildTrie,DefaultJob,False,Default,Default,Default,Default,Default,Default,1111111111111111,Empty,RyuJit,Default,X64,8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c,.NET 8.0,False,True,False,True,Default,Default,False,False,False,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,Default,16,Default,119.95 ms,2.367 ms,3.394 ms,120.68 ms,11000.0000,6600.0000,2000.0000,59.72 MB
"""

df = pd.read_csv(StringIO(csv_raw))

# Extract mean & std dev (strip ' ms')
for col in ["Mean", "StdDev"]:
    df[col] = df[col].str.replace(" ms", "", regex=False).astype(float)

# Bar plot (log‑y) with error bars
plt.figure()
plt.bar(
    df["Method"],
    df["Mean"],
    yerr=df["StdDev"],
    capsize=5
)
plt.yscale("log")
plt.xlabel("Method")
plt.ylabel("Dictionary‑build time (ms, log scale)")
plt.title("Dictionary Build Time by Method (±1σ)")
plt.tight_layout()
plt.show()
