import pandas as pd
import matplotlib.pyplot as plt

# 1. Load the CSV
csv_path = "ALGORITHMS.ASSIGNMENT2.PART1.SpellCheckerBenchmark-report.csv"
df = pd.read_csv(csv_path)

# 2. Clean and convert 'Mean' from "x,xxx.xx μs" to float milliseconds
df['Mean_us'] = (
    df['Mean']
      .str.replace(r'[,\sμs]', '', regex=True)
      .astype(float)
)
df['Mean_ms'] = df['Mean_us'] / 1000.0

# 3. Map file names to approximate sizes (in KB)
size_map = {
    'small.txt': 10,
    'medium.txt': 100,
    'AliceInWonderland.txt': 150
}
df['SizeKB'] = df['TextFileName'].map(size_map)

# 4. Plot Spell-Check time vs. text size
plt.figure()
for method in df['Method'].unique():
    subset = df[df['Method'] == method].sort_values('SizeKB')
    plt.plot(subset['SizeKB'], subset['Mean_ms'], marker='o', label=method)

plt.xscale('linear')
plt.yscale('log')
plt.xlabel('Text size (KB)')
plt.ylabel('Mean spelling time (ms, log scale)')
plt.title('Spell-Check Time vs. Text Size')
plt.legend()
plt.tight_layout()
plt.show()
