#!/usr/bin/env bash
set -euo pipefail

# Generate public WASM runtime config from Netlify environment variables.
# SUPABASE_URL and SUPABASE_KEY should be configured in Netlify site settings.

url="${SUPABASE_URL:-}"
key="${SUPABASE_KEY:-}"

if [[ -z "$url" || -z "$key" ]]; then
  echo "ERROR: SUPABASE_URL and SUPABASE_KEY must be set in Netlify environment variables." >&2
  exit 1
fi

cat > wwwroot/appsettings.json <<EOF
{
  "Supabase": {
    "Url": "$url",
    "Key": "$key"
  }
}
EOF

echo "Generated wwwroot/appsettings.json from Netlify environment variables."
