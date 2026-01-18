# Release Process

This document explains how to create releases for the Rock-Paper-Scissors game using our automated GitHub Actions workflow.

## Overview

The release workflow automatically builds platform-specific binaries and creates a GitHub release with all necessary assets. It supports both automated and manual release creation.

## Automated Release (Recommended)

The easiest way to create a release is by pushing a version tag to the repository.

### Steps

1. **Ensure your code is ready for release**
   ```bash
   # Make sure all changes are committed
   git status

   # Make sure you're on the main branch
   git checkout main
   git pull origin main
   ```

2. **Create and push a version tag**
   ```bash
   # Create a tag following semantic versioning (v1.0.0, v1.2.3, etc.)
   git tag v1.0.0

   # Push the tag to GitHub
   git push origin v1.0.0
   ```

3. **Monitor the workflow**
   - Go to the [Actions tab](https://github.com/felipedferreira/rock-paper-scissors-game/actions) in your repository
   - Watch the "Release" workflow execute
   - The workflow will:
     - Create a GitHub release
     - Generate a changelog from commits since the last tag
     - Build binaries for all supported platforms
     - Upload binaries to the release

4. **Verify the release**
   - Go to the [Releases page](https://github.com/felipedferreira/rock-paper-scissors-game/releases)
   - Verify the release was created with version `v1.0.0`
   - Check that all platform binaries are attached

## Manual Release

You can also trigger a release manually without creating a git tag first.

### Steps

1. **Navigate to GitHub Actions**
   - Go to your repository on GitHub
   - Click on the "Actions" tab
   - Select the "Release" workflow from the left sidebar

2. **Trigger the workflow**
   - Click the "Run workflow" button (top right)
   - Enter the version number (e.g., `v1.0.0`)
   - Click "Run workflow"

3. **The workflow will execute**
   - Creates a git tag with the specified version
   - Follows the same build and release process as automated releases

## Supported Platforms

Each release includes pre-built, self-contained executables for the following platforms:

| Platform | Runtime | Executable Name |
|----------|---------|----------------|
| Linux | x64 | `rock-paper-scissors-linux-x64` |
| Windows | x64 | `rock-paper-scissors-win-x64.exe` |
| macOS (Intel) | x64 | `rock-paper-scissors-osx-x64` |
| macOS (Apple Silicon) | ARM64 | `rock-paper-scissors-osx-arm64` |

All binaries are:
- **Self-contained** - No .NET runtime installation required
- **Single file** - Easy to distribute and run
- **Trimmed** - Optimized for smaller file size
- **Ready to run** - Just download and execute

## Versioning Guidelines

We follow [Semantic Versioning](https://semver.org/) (SemVer):

- **MAJOR** version (`v2.0.0`) - Incompatible API changes or major feature overhauls
- **MINOR** version (`v1.1.0`) - New features added in a backwards-compatible manner
- **PATCH** version (`v1.0.1`) - Backwards-compatible bug fixes

### Examples

- `v1.0.0` - Initial release
- `v1.0.1` - Bug fix release
- `v1.1.0` - New AI strategy added
- `v2.0.0` - Major refactor or breaking changes

## Changelog Generation

The workflow automatically generates a changelog by:
1. Finding the previous git tag
2. Extracting all commit messages between the previous tag and the current release
3. Formatting them as a bulleted list with commit hashes

### Writing Good Commit Messages

To ensure meaningful changelogs, write descriptive commit messages:

```bash
# Good examples
git commit -m "feat: add Rock-Paper-Scissors-Lizard-Spock mode"
git commit -m "fix: correct win/loss calculation for edge cases"
git commit -m "docs: update installation instructions"

# Poor examples (avoid these)
git commit -m "fix stuff"
git commit -m "updates"
git commit -m "wip"
```

Use conventional commit prefixes:
- `feat:` - New features
- `fix:` - Bug fixes
- `docs:` - Documentation changes
- `refactor:` - Code refactoring
- `test:` - Adding or updating tests
- `chore:` - Maintenance tasks

## Troubleshooting

### Workflow Failed During Build

**Symptom**: The workflow fails during the "Publish" step

**Solutions**:
- Check that all projects build successfully locally: `dotnet build`
- Verify .NET 10.0 SDK compatibility
- Review workflow logs in the Actions tab

### Release Created But Missing Binaries

**Symptom**: Release exists but some or all binaries are missing

**Solutions**:
- Check the workflow logs for the specific platform that failed
- Verify the "Upload Release Asset" step completed successfully
- Re-run the workflow if it was a temporary failure

### Tag Already Exists

**Symptom**: `git push origin v1.0.0` fails because tag already exists

**Solutions**:
```bash
# Delete local tag
git tag -d v1.0.0

# Delete remote tag (be careful!)
git push origin :refs/tags/v1.0.0

# Create new tag
git tag v1.0.0
git push origin v1.0.0
```

### Workflow Not Triggered

**Symptom**: Pushing a tag doesn't trigger the workflow

**Solutions**:
- Verify the tag follows the pattern `v*.*.*` (e.g., `v1.0.0`, not `1.0.0`)
- Check that the workflow file exists at `.github/workflows/release.yaml`
- Ensure GitHub Actions are enabled for the repository

## Best Practices

1. **Test before releasing**
   - Run the build workflow manually before creating a release
   - Test the application thoroughly on your local machine

2. **Use pre-releases for testing**
   - For major versions, consider creating a pre-release first
   - Tag as `v2.0.0-beta.1` for beta releases

3. **Document changes**
   - Update documentation before releasing
   - Include migration guides for breaking changes

4. **Coordinate timing**
   - Release during normal working hours
   - Avoid releasing on Fridays or before holidays

5. **Communicate**
   - Announce releases to users
   - Link to the release notes in announcements

## Release Checklist

Before creating a release, ensure:

- [ ] All tests pass locally
- [ ] Documentation is up to date
- [ ] CHANGELOG or commit messages are clear
- [ ] Version number follows semantic versioning
- [ ] No known critical bugs
- [ ] Code is reviewed and merged to main
- [ ] All CI checks pass

## Related Files

- `.github/workflows/release.yaml` - Release workflow configuration
- `.github/workflows/build.yaml` - Build and test workflow
- `README.md` - Main project documentation

## Additional Resources

- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [Semantic Versioning Specification](https://semver.org/)
- [.NET Publishing Documentation](https://docs.microsoft.com/en-us/dotnet/core/deploying/)
